using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace WebApplication1
{
    internal class XMLReadWithDOMApproach
    {
        internal static string[,] Read(string filepath)
        {
            // odczyt zawartości dokumentu
            XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            string postac;
            List<string> postacList = new List<string>();
            string sc;
            int count = 0;
            var date = doc.GetElementsByTagName("Date");
            var price = doc.GetElementsByTagName("Adj-Close");
            
            foreach (XmlNode d in date)
            {
                count++;
            }
            string[,] result = new string[count, 2];
            for (int i = 0;i< count; i++)
            {
                result[i, 0] = date[i].InnerText;
                result[i, 1] = price[i].InnerText;
            }
            return result;
           
        }
        internal static void roznePostaci(string filepath)
        {
            /*XmlDocument doc = new XmlDocument();
            doc.Load(filepath);

            string postac;
            Dictionary<string, string> nazwaList = new Dictionary<string, string>();
            string sc;
            int count = 0;
            var drugs = doc.GetElementsByTagName("produktLeczniczy");
            foreach (XmlNode d in drugs)
            {
                postac = d.Attributes.GetNamedItem("postac").Value;
                sc = d.Attributes.GetNamedItem("nazwaPowszechnieStosowana").Value;

                if ((!nazwaList.ContainsKey(sc)) && (!nazwaList.ContainsValue(postac)) || ((!nazwaList.ContainsKey(sc)) && (nazwaList.ContainsValue(postac))))
                {
                    nazwaList.Add(sc, postac);
                }
                if ((nazwaList.ContainsKey(sc)) && (!nazwaList.ContainsValue(postac)))
                {
                    count++;
                }
            }

            foreach (KeyValuePair<string, string> temp in nazwaList)
            {
                Console.WriteLine("Nazwy: {0} |||| {1}", temp.Key, temp.Value);

            }
            Console.WriteLine("Różne Postaci: {0}", count);*/
        }
        internal static void maximum(string filepath)
        {
           /* XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            int sc_max = 0;
            string postac = "";
            string podmiotKrem = "";
            string podmiotTab = "";
            string podmiotTemp = "";
            Dictionary<string, int> podmiotLista = new Dictionary<string, int>();
            Dictionary<string, int> podmiotTabletkiLista = new Dictionary<string, int>();
            var drugs = doc.GetElementsByTagName("produktLeczniczy");
            // analiza każdego z węzłów dokumentu
            foreach (XmlNode d in drugs)
            {
                    postac = d.Attributes.GetNamedItem("postac").Value;
                    int result;
                    podmiotTemp = d.Attributes.GetNamedItem("podmiotOdpowiedzialny").Value;

                    if (postac == "Krem")
                    {

                        if (podmiotLista.ContainsKey(podmiotTemp))
                        {
                            podmiotLista.TryGetValue(podmiotTemp, out result);
                            podmiotLista.Remove(podmiotTemp);
                            podmiotLista.Add(podmiotTemp, result + 1);

                        }
                        else
                        {
                            podmiotLista.Add(podmiotTemp, 1);
                        }


                    }
                    if (postac == "Tabletki")
                    {

                        if (podmiotTabletkiLista.ContainsKey(podmiotTemp))
                        {
                            podmiotTabletkiLista.TryGetValue(podmiotTemp, out result);
                            podmiotTabletkiLista.Remove(podmiotTemp);
                            podmiotTabletkiLista.Add(podmiotTemp, result + 1);

                        }
                        else
                        {
                            podmiotTabletkiLista.Add(podmiotTemp, 1);
                        }


                    }


                

            }
            foreach (KeyValuePair<string, int> temp in podmiotLista)
            {
                if (temp.Value > sc_max)
                {
                    sc_max = temp.Value;
                    podmiotKrem = temp.Key;
                }
            }

            Console.WriteLine("Maximum dla kremow: {0} {1}", podmiotKrem, sc_max);
            sc_max = 0;
            foreach (KeyValuePair<string, int> temp in podmiotTabletkiLista)
            {
                if (temp.Value > sc_max)
                {
                    sc_max = temp.Value;
                    podmiotTab = temp.Key;
                }
            }
            Console.WriteLine("Maximum dla tabletek: {0} {1}", podmiotTab, sc_max);*/
        }

        internal static void trzyPostaci(string filepath)
        {
          /*  XmlDocument doc = new XmlDocument();
            doc.Load(filepath);
            string postac = "";
            string podmiotTemp = "";
            Dictionary<string, int> podmiotLista = new Dictionary<string, int>();
            Dictionary<string, int> podmiotTabletkiLista = new Dictionary<string, int>();
            var drugs = doc.GetElementsByTagName("produktLeczniczy");
            // analiza każdego z węzłów dokumentu
            foreach (XmlNode d in drugs)
            {
                postac = d.Attributes.GetNamedItem("postac").Value;
                int result;
                podmiotTemp = d.Attributes.GetNamedItem("podmiotOdpowiedzialny").Value;

                if (postac == "Krem")
                {

                    if (podmiotLista.ContainsKey(podmiotTemp))
                    {
                        podmiotLista.TryGetValue(podmiotTemp, out result);
                        podmiotLista.Remove(podmiotTemp);
                        podmiotLista.Add(podmiotTemp, result + 1);

                    }
                    else
                    {
                        podmiotLista.Add(podmiotTemp, 1);
                    }


                }

            }
            var sorted = podmiotLista.OrderByDescending(entry => entry.Value);
            var a = sorted.Take(3);
            foreach (KeyValuePair<string, int> value in a)
            {
                Console.WriteLine("Maximum dla 3 kremow: {0} {1}", value.Key, value.Value);
            }
*/
        }

    }
}