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
<h2>Ekran powitalny aplikacji</h3><br>
<p>Jest to pierwszy ekran który widzimy po uruchomieniu aplikacji <br>Z tego miejsca możemy przejść do rejestracji oraz logowania jeżeli użykownik posiada już konto</p>
<h4>Opis klasy <code>WelcomeForm</code></h4>
<p>Klasa <code>WelcomeForm</code> reprezentuje główny formularz aplikacji hotelowej.<br>Zawiera przyciski do logowania i rejestracji</p>
<h4>Metody:</h5>
<ul>
  <li><b>InitializeComponents()</b>: Inicjalizuje wszystkie komponenty formularza, takie jak przyciski i obrazek, oraz definiuje ich właściwości i zachowanie.</li>
  <li><b>LoadImageFromUrl(string url)</b>: Ładuje obrazek z podanego URL do kontrolki PictureBox.</li>
  <li><b>ApplyCustomStyles()</b>: Stosuje niestandardowe style do formularza, takie jak tło i czcionka.</li>
</ul>
<br>
<img src="https://github.com/plowigus/programowanie_obiektowe_wsb/blob/main/Zrzut%20ekranu%202024-06-22%20123128.png">
<h2>Ekran rejestracji </h3><br>
<p><code>RegisterForm</code> jest kluczowym elementem interfejsu użytkownika aplikacji hotelowej, umożliwiającym nowym użytkownikom rejestrację poprzez wprowadzenie podstawowych danych personalnych. Formularz jest odpowiednio stylizowany i integruje się z bazą danych aplikacji przez <code>DatabaseManager</code>, zapewniając bezpieczeństwo i integralność danych użytkowników.</p>


