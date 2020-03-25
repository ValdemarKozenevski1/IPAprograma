# IPAprograma
IPA dalyko programa

## v0.1 ##

Sukurtas studentų įvedimas ranka ir jų išvedimas ant ekrano skaičiuojant bendrą pažymių vidurkį arba medianą.

Naudotis: 
1. Spaudžiame 1 ("1. Ivesite studentu duomenis");
2. Prašoma suvesti studento vardą, pavardę ir pažymius (galima pasirinkti kad programa pati "random" skaičius paduotų tarsi pažymiai nuo 0 iki 10).
2. Pasirenkama ar norime medianą ar vidurkį;
3. Išveda lentelę į ekraną su pažymių vidrukių arba medianą, vardais, pavardėm.

## v0.2 ##

Pridėtas nuskaitymas iš failų (kaip "Testavimo failas"). Ir padarytas rušiavimas.

Naudotis:
1. Spaudžiame 2 ("2. Ivesite duomenu faila");
2. Nurodome kelia į failą, kuri norime nuskaityti.

## v0.3 ##
Pridėtas išimčių valdymas ir pataisytos smulkios klaidos 

## v0.4 ##

Sukurta galimybė generuoti skirtingų dydžio studentų failus ir tada juos padalinti į du failus pagal reikalavimus, priklausomai nuo vidurkio. Pridėta šios funkcijos greičio matavimo galimybė. 

Naudotis:
1. Spaudžiame 3 ("3. Atlikti benchmark'a");
2. Gauname lentelę su rezultatais.

|          Stud sk          |        Init       |        Split        |      Sort       |  Write #1   |  Write #2  |   
|-|-|-|-|-|-|
|        1000        |         0:00.2         |         0:00.0      |         0:00.3         |         0:00.11         |         0:00.7         | 
|       10000        |         0:00.18        |         0:00.1      |         0:00.38        |         0:00.24        |         0:00.16         |  
|       100000       |         0:00.244       |       0:00.12        |           0:00.530         |         0:00.155       |         0:00.95        | 
|      1000000       |         0:02.674       |         0:00.85      |         0:07.482         |         0:01.612         |        0:00.959       | 
|      10000000      |        0:27.316        |        0:00.837    |        1:36.23         |        0:15.464         |        0:09.410        |  

(Stud sk- studentu skaičius, Init - visų studentų sukūrimas, Split ir sort - "splitina" i dviejus listus ir "sortina" pagal vidurkį, Write #1/Write#2 atitinkamai įrašo į failą priklausomai nuo vidurkio.)

## v0.5 ##
Padarytas skaičiavimas su 3 skirtingais konteineriais "List", "LinkedList" ir "Queue".

Naudotis:
1. Spaudžiame 4 ("4. Atlikti konteineriu benchmark'a");
2. Gauname lentelę su rezultatais.

Student list size: 100000
|          Stud sk          |        Init       |        Split        |      Sort       |  Write   |    
|-|-|-|-|-|
|        List          |         0:00.259       |         0:00.8  |         0:00.540     |    0:00.251         |         
|       LinkedList    |        0:00.533     |         2:01.315  |         0:00.552       |    0:00.3            |          
|       Queue         |      0:00.264     |       0:38.612    |           0:00.2        |         0:00.242    |    

## v1.0 ##
Panaudotos 2 strategijos. Sutvarkytas "README.md" failas.

Naudotis:
1. Spaudžiame 5 ("5. Atlikti 2 strategiju benchmark'a");
2. Gauname lentelę su rezultatais.

Student list size: 100000
|           Strategy        |        Init       |        Split        |      Sort       |  Write    |    
|-|-|-|-|-|
|        List/NoDel        |         0:00.258         |         0:00.7     |         0:00.538        |         0:00.249        |         
|       List/WithDel       |         0:00.241        |         0:00.21     |         0:00.527       |         0:00.2        |         
|       LinkedList/DelFirst   |         0:00.280      |       0:00.44       |           0:00.545         |         0:00.1  |         
|     LinkedList/DelLast      |         0:00.274       |         2:01.709      |         0:00.539         |         0:00.3     |        
|      Queue/First      |        0:00.258        |        0:00.8   |        0:00.559         |        0:00.2         |
|      Queue/ElementAt     |        0:00.251        |        0:37.742    |        0:00.00         |        0:00.241         |

## Testavimo įranga ##

1. Operacinė sistema: Windows 10 PRO, v.1909
2. Procesorius: Intel core I5-7600K 
3. RAM: 8 GB  
4. Diskas: Samsung EVO860 SSD 500 GB

## Instaliavimas ##

1. Užeikite į "ValdemarKozenevski1" "github" paskyrą;
2. Pasirinkite "IPAprograma";
3. Spauskite "Realeses";
4. Suraskite versiją v1.0 ir spauskite "Assets";
5. Atsiuskite "IPAprograma.exe" ir paleiskite arba galite atsiųsti "suzipintą" kodą ir paleisti per "VisualStudio".

       










