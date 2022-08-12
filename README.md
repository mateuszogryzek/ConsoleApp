Program wyrzucał błędu z powodu: 

* W klasie program błędnie wpisana nazwa pliku do odczytu 

* W klasie ImportedObject niepotrzebnie dodany obiekt listy tworzył nullowy pierwszy element tej lisy 

* Pierwsza pętla for była źle zbudowana ( i <= importerLines.Count) 

* Plik data.csv posiadal puste linie i w jednej lini o jeden element za dużo 

Czystość kodu: 

* Moim zdaniem niepotrzebnie została stworzona klasa bazowa ImportedOBjectBaseClass, a brakowało rozbicia klasy DataReader, która posiadała w sobie dwie funkcjonalności, odczyt danych i wyświetlenie danych, dlatego stworzyłem nową klasę z metodą PrintData, która przyjmuje listę obiektów z ImportData i wyświetla dane w konsoli. 

* W metodzie ImportAndPrintData była nieużywana zmienna boolean, w metodzie PrintData dodałem zmienną isDataPrint, gdy użytkownik poda false, dane niezostaną wypisane na ekranie. 

* Zbędne usingi można usunąć. 

* Dodanie try catch w DataReader zabezpieczy aplikację przed “wysypaniem” gdy np. wprowadzona zostanie niepoprawna ścieżka do pliku i na ekranie zostanie wyświetlona informacja co spowodowało błąd.  
