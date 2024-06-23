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
<h2>Metody <code>RegisterForm</code></h2>
<ul>
  <h3>Metoda <code>registerButton_Click(object sender, EventArgs e)</code></h3>
  <li>Obsługuje zdarzenie kliknięcia przycisku `registerButton` </li>
  <li>Przeprowadza walidację wprowadzonych danych przez użytkownika.</li>
  <li>Tworzy nowego użytkownika w bazie danych przy użyciu <code>databaseManager.AddUser(firstName, lastName, email, password)</code>.</li>  
</ul>
<br>
<br>

<img src="https://github.com/plowigus/programowanie_obiektowe_wsb/blob/main/Zrzut%20ekranu%202024-06-22%20123118.png">
<h2>Ekran logowania </h3><br>
<p>Klasa <code>LoginForm</code> jest formularzem logowania dla aplikacji hotelowej. Umożliwia użytkownikowi wprowadzenie adresu e-mail oraz hasła, a następnie weryfikację danych w bazie danych. Formularz zawiera także opcję przejścia do rejestracji oraz wyświetla obrazek.</p>
<h2>Metody <code>LoginForm</code></h2>
<ul>
  <h3>Metoda <code>loginButton_Click(object sender, EventArgs e)</code></code></h3>
  <li>Metoda obsługująca kliknięcie przycisku logowania. Sprawdza, czy pola tekstowe nie są puste, a następnie weryfikuje dane logowania w bazie danych. </li>
  <li>Sprawdzenie, czy pola <code>emailTextBox</code> i <code>passwordTextBox</code> są puste. Jeśli tak, wyświetlenie komunikatu o błędzie.</li>
  <li>Pobranie wartości z pól tekstowych.</li>
  <li>Weryfikacja użytkownika za pomocą metody <code>databaseManager.AuthenticateUser(email, password).</code></li>
  <li>Jeśli weryfikacja się powiedzie, wyświetlenie komunikatu o sukcesie, ukrycie bieżącego formularza i wyświetlenie <code>MainViewForm</code>.</li>
  <li>Jeśli weryfikacja się nie powiedzie, wyświetlenie komunikatu o błędzie logowania.</li>  
</ul>
<br>
<br>


<img src="https://github.com/plowigus/programowanie_obiektowe_wsb/blob/main/Zrzut%20ekranu%202024-06-23%20113721.png">
<h2>Ekran główny aplikacji </h3><br>
<p>Klasa <code>MainViewForm</code> jest głównym formularzem aplikacji hotelowej. Formularz ten zawiera przyciski do zarządzania rezerwacjami oraz dodawania nowych pokoi i rezerwacji. Dodatkowo formularz wyświetla obrazek związany z hotelem. Klasa <code>MainViewForm</code> zawiera trzy przyciski umożliwiające zarządzanie rezerwacjami oraz dodawanie nowych pokoi i rezerwacji. Ponadto wyświetla obraz związany z hotelem. Wszystkie komponenty są starannie rozmieszczone i stylizowane, aby zapewnić spójny wygląd i działanie aplikacji.</p>
<br>
<br>

<img src="https://github.com/plowigus/programowanie_obiektowe_wsb/blob/main/Zrzut%20ekranu%202024-06-22%20123118.png">
<h2>Ekran dodawania pokoju</h3><br>
<p>Klasa <code>AddRoomForm</code> jest formularzem służącym do dodawania nowych pokoi do bazy danych aplikacji hotelowej. Umożliwia użytkownikowi wprowadzenie numeru pokoju, typu pokoju oraz ceny za noc. Formularz zawiera także opcję powrotu do głównego widoku oraz wyświetla obrazek.</p>
<h2>Metody <code>AddRoomForm</code></h2>
<ul>
  <h3>Metoda <code>addButton_Click(object sender, EventArgs e)</code></code></h3>
  <li>Sprawdzenie, czy pola <code>roomNumberTextBox</code>, <code>roomTypeComboBox</code> i <code>pricePerNightTextBox</code> są puste. Jeśli tak, wyświetlenie komunikatu o błędzie.</li>
  <li>Walidacja numeru pokoju. Musi być dodatnią liczbą całkowitą.</li>
  <li>Walidacja ceny za noc. Musi być dodatnią liczbą.</li>
  <li>Pobranie wartości z pól tekstowych.</li>
  <li>Dodanie nowego pokoju do bazy danych za pomocą metody <code>databaseManager.AddRoom(roomNumber, roomType, pricePerNight, isAvailable)</code>.</li>
  <li>Wyświetlenie komunikatu o sukcesie.</li>  
</ul>
<br>
<br>
