using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using Week4.Library.ClientAPI.Contract;

namespace Week4.Library.ClientAPI
{
    class Menu
    {
        internal static void Start()
        {
            bool quit = false;
            char choice;
            do
            {
                Console.WriteLine("\nSeleziona un'opzione del menu" +
                "\n[ 1 ] - Aggiungi nuovo libro" +
                "\n[ 2 ] - Elimina un libro" +
                "\n[ 3 ] - Gestisci la presa in prestito di un libro" +
                "\n[ 4 ] - Visualizza la lista delle attività (Prestiti /Resi)" +
                "\n[ q ] - ESCI");



                choice = Console.ReadKey().KeyChar;



                switch (choice)
                {
                    case '1':
                        AddBook();
                        break;
                    case '2':
                        DeleteBook();
                        break;
                    case '3':
                        AddPrestito();
                        break;
                    case '4':
                        ShowPrestitiResi();
                        break;
                    case 'q':
                        quit = true;
                        break;
                    default:
                        Console.WriteLine("\nScelta sconosciuta.");
                        break;
                }



            } while (!quit);
        }

        private static void ShowPrestitiResi()
        {
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44318/api/prestiti")
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            //if(response.StatusCode == System.Net.HttpStatusCode.OK) //se risp da ok  -> la recupero come stringa
            if (response.IsSuccessStatusCode)
            {
                string data = response.Content.ReadAsStringAsync().Result;

                //Deserializzazione (da stringa (json) -> oggetto di C#)
                var result = JsonConvert.DeserializeObject<List<PrestitoContract>>(data);

                foreach (PrestitoContract p in result)
                {
                    Console.WriteLine($"\nId prestito : {p.Id} - IdLibro : {p.IdLibro} - {p.Utente} - DataP: {p.DataPrestito} - Reso : {p.DataReso}");
                }
            }
        }

        private static void AddPrestito()
        {
            string utente = GetData("Utente che richiede il prestito");
            DateTime dataPrestito = GetDate();
            int idLibro = GetId();

            HttpClient client = new HttpClient();

            HttpRequestMessage postRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:44318/api/prestiti")
            };

            PrestitoContract newPrestito = new PrestitoContract
            {
                Utente = utente,
                IdLibro = idLibro,
                DataPrestito = dataPrestito
            };

            //passo da c#a json -> lo trasformo in stringa
            string newPrestitoJson = JsonConvert.SerializeObject(newPrestito);

            postRequest.Content = new StringContent(
                newPrestitoJson,
                Encoding.UTF8,
                "application/json");

            //recupero la risposta

            HttpResponseMessage postResponse = client.SendAsync(postRequest).Result;

            if (postResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                string data = postResponse.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<PrestitoContract>(data);

                Console.WriteLine($"Prestito aggiunto con Id {result.Id}");
            }
        }

        private static DateTime GetDate()
        {
            DateTime data = new DateTime();
            do
            {
                Console.WriteLine("\nInserisci la data del prestito");

            } while (!DateTime.TryParse(Console.ReadLine(), out data) || data < DateTime.Now);

            return data;
        }

        private static void DeleteBook()
        {
            int id = GetId();
            HttpClient client = new HttpClient();

            HttpRequestMessage request = new HttpRequestMessage
            {
                Method = HttpMethod.Delete,
                RequestUri = new Uri("https://localhost:44318/api/books/"+ $"{id}")
            };

            HttpResponseMessage response = client.SendAsync(request).Result;

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("\nLibro eliminato");
            }
            else Console.WriteLine("\nLibro NON eliminato");
        }

        private static int GetId()
        {
            int id;

            do
            {
                Console.WriteLine("\nInserisci l'Id del libro");
            } while (!int.TryParse(Console.ReadLine(), out id) || id <= 0);
            return id;
        }

        private static void AddBook()
        {
            string isbn = GetData("Isbn");
            string author = GetData("Autore");
            string title = GetData("Titolo");

            HttpClient client = new HttpClient();

            HttpRequestMessage postRequest = new HttpRequestMessage
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:44318/api/books")
            };

            BookContract newBook = new BookContract
            {
                Isbn = isbn,
                Author = author,
                Title = title
            };

            //passo da c#a json -> lo trasformo in stringa
            string newBookJson = JsonConvert.SerializeObject(newBook);

            postRequest.Content = new StringContent(
                newBookJson,
                Encoding.UTF8,
                "application/json");

            //recupero la risposta

            HttpResponseMessage postResponse = client.SendAsync(postRequest).Result;

            if (postResponse.StatusCode == System.Net.HttpStatusCode.Created)
            {
                string data = postResponse.Content.ReadAsStringAsync().Result;

                var result = JsonConvert.DeserializeObject<BookContract>(data);

                Console.WriteLine($"\nLibro aggiunto con Id {result.Id}");
            }
        }

        private static string GetData(string field)
        {
            string inseredField;
            do
            {
                Console.WriteLine($"\nInserisci il campo {field}");
                inseredField = Console.ReadLine();
                if (inseredField.Length < 10)
                    inseredField = null;
            } while (string.IsNullOrEmpty(inseredField));

            return inseredField;
        }
    }
}
