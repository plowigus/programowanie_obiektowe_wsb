<h1>Hotel Managment System</h1>
<h2>1. Opis<br></h2>
<p>Aplikacja "WSB Hotel App" jest częścią projektu związanego z kursami programowania obiektowego na Merito WSB. <br> Została zaprojektowana do zarządzania rezerwacjami oraz operacjami związanymi z obsługą hotelową.</p>
<br>
<h2>2. Instalacja</h2>
<p>
  <ul>
    <li>Język programowania: <b>C#</b></li>
    <li>Środowisko uruchomieniowe: <b>Visual Studio</b></li>
    <li>Dodatkowe biblioteki: <b>EntityFramework, SQLite</b></li>
  </ul>

<h3>Instrukcje instalacji</h3>

<ul>
  <li>Sklonuj repozytorium na swój lokalny komputer:
    <code>git clone https://github.com/plowigus/programowanie_obiektowe_wsb.git</code>
  </li>
  <li>Przejdź do katalogu <b>"wsb_hotel_app"<b>:
    <code>cd wsb_hotel_app</code>
  </li>
  <li>Uruchom aplikację</li>
</ul>
<h2>3. Użytkowanie</h2><br>
<img src="https://github.com/plowigus/programowanie_obiektowe_wsb/blob/main/Zrzut%20ekranu%202024-06-22%20123105.png">
<h3>*Ekran powitalny aplikacji</h3><br>
<p>Jest to pierwszy ekran który widzimy po uruchomieniu aplikacji <br>Z tego miejsca możemy przejść do rejestracji oraz logowania jeżeli użykownik posiada już konto</p>
<h4>Opis klasy <code>MainViewForm</code></h4>
<p>Klasa <code>MainViewForm</code> reprezentuje główny formularz aplikacji hotelowej.<br>Zawiera przyciski do przeglądania listy rezerwacji, dodawania nowych pokoi oraz dodawania nowych rezerwacji. <br>Dodatkowo wyświetla obrazek reprezentujący hotel.</p>
<h5>Metody:</h5>
<ul>
  <li><b>InitializeComponents()</b>: Inicjalizuje wszystkie komponenty formularza, takie jak przyciski i obrazek, oraz definiuje ich właściwości i zachowanie.</li>
  <li><b>LoadImageFromUrl(string url)</b>: Ładuje obrazek z podanego URL do kontrolki PictureBox.</li>
  <li><b>ApplyCustomStyles()</b>: Stosuje niestandardowe style do formularza, takie jak tło i czcionka.</li>
</ul>
<br>
<img src="https://github.com/plowigus/programowanie_obiektowe_wsb/blob/main/Zrzut%20ekranu%202024-06-22%20123128.png">
<h3>*Ekran rejestracji </h3><br>
<p></p>


