// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using System.Net.Http.Headers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

var client = new HttpClient();
var cliente = new HttpClient();
string pokemonnn = "";
string pokedex = "valor1";
string elegido = "";
string remplazo = "";
int vidas = 6;
string url = "";
int num =0;
StringBuilder remplazado = new StringBuilder(remplazo);

List<string> elementos = new List<string>();
List<string> elementoss = new List<string>();
List<string> tipop = new List<string>();
string tipokemon = "";
string powerpokemon = "";
string peso = "";




var request = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    //RequestUri = new Uri("https://pokedex2.p.rapidapi.com/pokedex/usa/pikachu"),
    /*Headers =
    {
        { "X-RapidAPI-Key", "8b612b5078msheef33a9277fb744p1dbfddjsne0206765bd88" },
        { "X-RapidAPI-Host", "pokedex2.p.rapidapi.com" },
    },*/
    RequestUri = new Uri("https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0")
};
using (var response = await client.SendAsync(request))
{
    response.EnsureSuccessStatusCode();
    string body = await response.Content.ReadAsStringAsync();
    Console.WriteLine(body);
    JObject jsonObject = JsonConvert.DeserializeObject<JObject>(body);

    JArray resultsArray = (JArray)jsonObject["results"];
    int i = 0;
    foreach (JObject result in resultsArray)
    {
        
        string nombre = (string)result["name"];
        string enlace = (string)result["url"];
      
        pokemonnn = nombre;
        elementos.Add(nombre);
        elementoss.Add(enlace);

        Console.WriteLine($"Nombre: {nombre}");
        i++;
    }
    Random r = new Random();
    int pez=r.Next(0, elementos.Count);
    url= elementoss[pez];
    elegido = elementos[pez];
     
    for(int p=0;p<=elegido.Length-1;p++)
    {
        remplazo = remplazo + "_";
    }
  
   
    //tablero();
}
Console.WriteLine("uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu");
var linkkkk = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    //RequestUri = new Uri("https://pokedex2.p.rapidapi.com/pokedex/usa/pikachu"),
    /*Headers =
    {
        { "X-RapidAPI-Key", "8b612b5078msheef33a9277fb744p1dbfddjsne0206765bd88" },
        { "X-RapidAPI-Host", "pokedex2.p.rapidapi.com" },
    },*/
    RequestUri = new Uri(url)
};
using (var respuesta = await cliente.SendAsync(linkkkk))
{
    respuesta.EnsureSuccessStatusCode();
    string poke = await respuesta.Content.ReadAsStringAsync();
    Console.WriteLine(poke);
    JObject jsonObject = JsonConvert.DeserializeObject<JObject>(poke);

    string  resultsArray = jsonObject["weight"].ToString();
    // JArray resultsArrays = (JArray)jsonObject["weight"];

    peso= resultsArray;
    
    

        

     


       


    


}
Console.WriteLine("uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu");
var linkk = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    //RequestUri = new Uri("https://pokedex2.p.rapidapi.com/pokedex/usa/pikachu"),
    /*Headers =
    {
        { "X-RapidAPI-Key", "8b612b5078msheef33a9277fb744p1dbfddjsne0206765bd88" },
        { "X-RapidAPI-Host", "pokedex2.p.rapidapi.com" },
    },*/
    RequestUri = new Uri(url)
};
using (var respuesta = await cliente.SendAsync(linkk))
{
    respuesta.EnsureSuccessStatusCode();
    string poke = await respuesta.Content.ReadAsStringAsync();
    Console.WriteLine(poke);
    JObject jsonObject = JsonConvert.DeserializeObject<JObject>(poke);

    JArray resultsArray = (JArray)jsonObject["abilities"];
    // JArray resultsArrays = (JArray)jsonObject["weight"];

    int i = 0;
    foreach (JObject result in resultsArray)
    {

        string habilidad = (string)result["ability"]["name"];
        
       powerpokemon = powerpokemon + " " + habilidad;


        Console.WriteLine($"Nombre: {habilidad}");


    }


}
Console.WriteLine("uuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuuu");
var linkkk = new HttpRequestMessage
{
    Method = HttpMethod.Get,
    //RequestUri = new Uri("https://pokedex2.p.rapidapi.com/pokedex/usa/pikachu"),
    /*Headers =
    {
        { "X-RapidAPI-Key", "8b612b5078msheef33a9277fb744p1dbfddjsne0206765bd88" },
        { "X-RapidAPI-Host", "pokedex2.p.rapidapi.com" },
    },*/
    RequestUri = new Uri(url)
};
using (var respuesta = await cliente.SendAsync(linkkk))
{
    respuesta.EnsureSuccessStatusCode();
    string poke = await respuesta.Content.ReadAsStringAsync();
    Console.WriteLine(poke);
    JObject jsonObject = JsonConvert.DeserializeObject<JObject>(poke);

    JArray resultsArray = (JArray)jsonObject["types"];
   // JArray resultsArrays = (JArray)jsonObject["weight"];

    int i = 0;
    foreach (JObject result in resultsArray)
    {

        string tipo = (string)result["type"]["name"];
        tipop.Add(tipo);
        tipokemon=tipokemon+" "+ tipo;


        Console.WriteLine($"Nombre: {tipo}");


    }
   

    tablero();
}



void responder()
{
    int existe = 0;
    Console.WriteLine("Ingresar una letra o un[-]");
    char usuario=char.Parse(Console.ReadLine().ToLower());
    char[] chars = remplazo.ToCharArray();
    for (int p = 0; p < elegido.Length ; p++)
    {
        if (usuario == elegido[p])
        {

            chars[p]=usuario;
            remplazo=new string(chars);
            existe = 1;
            
        }
    }
    if(existe == 0 )
    {
        vidas = vidas - 1;
    }
    tablero();

}
void fin()
{
    Console.WriteLine("Gracias por jugar :)");
  

    Environment.Exit(0);
}
void tablero()
{
    Console.BackgroundColor= ConsoleColor.Gray;
    Console.Clear();
    switch (vidas)
    {
        case 0:
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(" _____");
            Console.WriteLine(" |    |");
            Console.WriteLine(" |    O/");
            Console.WriteLine(" |   /|");
            Console.WriteLine(" |   / |");
            Console.WriteLine(" |________");
            break; 
        case 1:
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" _____");
            Console.WriteLine(" |    |");
            Console.WriteLine(" |    O/");
            Console.WriteLine(" |   /|");
            Console.WriteLine(" |   / ");
            Console.WriteLine(" |________");
            break; 
        case 2:
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(" _____");
            Console.WriteLine(" |    |");
            Console.WriteLine(" |    O/");
            Console.WriteLine(" |   /|");
            Console.WriteLine(" |    ");
            Console.WriteLine(" |________");

            break;
        case 3:
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(" _____");
            Console.WriteLine(" |    |");
            Console.WriteLine(" |    O/");
            Console.WriteLine(" |    |");
            Console.WriteLine(" |    ");
            Console.WriteLine(" |________");
            break;
        case 4:
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(" _____");
            Console.WriteLine(" |    |");
            Console.WriteLine(" |    O");
            Console.WriteLine(" |    |");
            Console.WriteLine(" |    ");
            Console.WriteLine(" |________");
            break;
        case 5:
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(" _____");
            Console.WriteLine(" |    |");
            Console.WriteLine(" |    O");
            Console.WriteLine(" |    ");
            Console.WriteLine(" |    ");
            Console.WriteLine(" |________");
            break;
        case 6:
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" _____");
            Console.WriteLine(" |    |");
            Console.WriteLine(" |    ");
            Console.WriteLine(" |    ");
            Console.WriteLine(" |    ");
            Console.WriteLine(" |________");
           
            break;
    }
    Console.ForegroundColor= ConsoleColor.Black;
    
    Console.WriteLine(elegido);//<----solo comente  para que no se le muestre al jugador si no esta comentado es para verificar si es dicha palabra
    Console.WriteLine(remplazo);
    if(vidas==0)
    {
        Console.WriteLine("perdiste");
        Console.WriteLine("El pokemon era: "+elegido);
        Console.WriteLine("tipo:" + tipokemon);
        Console.WriteLine("habilidades:" + powerpokemon);
        Console.WriteLine("peso:" + peso);
        // Console.WriteLine("tipo:" + tipop[0]);
        Console.WriteLine(url);
        Console.WriteLine("Ingresa una [r] para reiniciar o cualquier caracter para salir");
        char opcion = char.Parse(Console.ReadLine().ToLower());
        switch (opcion)
        {
            case 'r':
                Random r = new Random();
                elegido = elementos[r.Next(0, elementos.Count)];
                Console.WriteLine(elegido);
                remplazo = "";
                vidas = 6;
                for (int p = 0; p <= elegido.Length - 1; p++)
                {
                    remplazo = remplazo + "_";
                }
                tablero();
                break;
           
                

                

        }
        fin();

    }
    if (elegido==remplazo)
    {
        Console.WriteLine("ganaste");
        Console.WriteLine("Pokemon: "+elegido);
        Console.WriteLine("tipo:" + tipokemon);
        Console.WriteLine("habilidades:" + powerpokemon);
        Console.WriteLine("peso:" + peso);
        // Console.WriteLine("tipo:" + tipop[0]);
        Console.WriteLine(url);


        Console.WriteLine("Ingresa una [r] para reiniciar o cualquier caracter para salir");
        char opcion = char.Parse(Console.ReadLine().ToLower());
        switch(opcion)
        {
            case 'r':
                Random r = new Random();
                elegido = elementos[r.Next(0, elementos.Count)];
                Console.WriteLine(elegido);
                remplazo = "";
                vidas = 6;
                for (int p = 0; p <= elegido.Length - 1; p++)
                {
                    remplazo = remplazo + "_";
                }
                tablero();
                break;
              
               

                
               
        }
        fin();
    }
   
    responder();








}

