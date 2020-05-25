using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Codenation.Challenge
{
    public class Country
    {
        public State[] Top10StatesByArea()
        {
            List<Statearea> listA = new List<Statearea>();                                              //listA irá conter os atributos Name, Acronym e Area extraidos do csv
            var path = @"/home/engwill/codenation/csharp-3/Source/estados.csv";                 
            using (var reader = new StreamReader(path, Encoding.GetEncoding("iso-8859-1")))             //precisei utilizar o Encoding.GetEncoding(iso) devido a dificuldade que tive com acentuação
            {
                int i = 0;
                string[] values;
                while (!reader.EndOfStream)                                                             //dentro do loop todas as linhas do csv sao lidas, seperadas e gravadas na listA
                {
                    string line = reader.ReadLine();
                    values = line.Split(',');
                    listA.Add(new Statearea(values[0], values[1], Convert.ToInt32(values[2])));
                    i += 1;
                }
            }
            
            var sortStates = listA.OrderByDescending(i => i.Area);                                      //organiza a lista na ordem decrescente do maior para a menor area
            List<State> listB = sortStates.Select(s => new State(s.Name,s.Acronym)                      //remove a coluna area
            {
                Name = s.Name,
                Acronym = s.Acronym
            }).ToList();
            return listB.Take(10).ToArray();                                                            //pega os 10 estados e os retorna como o resultado do metodo Top10StatesByArea
        }
        public class Statearea                                                                          //Classe Statearea contendo as mesmas atribuições que State porem com adicao da atribuicao area
        {
            public Statearea(string name, string acronym, int area)
            {
                this.Name = name;
                this.Acronym = acronym;
                this.Area = area;
            }
            public string Name { get; set; }
            public string Acronym { get; set; }
            public int Area { get; set; }
        }
    }
}


/*
first line of CSV content https://www.ibge.gov.br/cidades-e-estados 
Acre,AC,164123964   
*/
