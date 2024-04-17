Transaction project

1. (Koriscenje Projekta)
- Klonirajte ili preuzmite projekat sa GitHub repozitorijuma.
- Nakon pokretanja aplikacije, pristupite API endpointovima putem HTTP klijenta ( Postman).
- Endpoint za transakcije mogu se pozvati sa odgovarajuci HTTP zahtevima (POST).
- Projekat koristi biblioteku za logovanje (Serilog) kako bi zabelezio relevantne dogadjaje i informacije.
- Logovi se mogu konfigurisati da se salju na razlicite izlaze, kao sto su konzola, fajl.
- Pratite logove radi pracenja stanja aplikacije, identifikacije gresaka ili problema u sistemu.

2. (Sta uraditi da bi zadatak bio bolji)
 - Unit testovi za servise: Implementirajte unit testove.
- Bolji error handling: Dodavanje detaljnije opise gresaka i vise razlicitih statusnih kodova kako bi korisnici lakse razumeli problem i kako bi se razlikovale razlicite vrste gresaka koriscenjem (tra,catch).
- Da se ispostuje Celan Arhitektura: da se podele projekti na slojeve(Presentation sloj,Application sloj,Infrastructure sloj) u samom projektu sam gledao da ispostujem Clean Arhitekturu po folderim.
- Iskoristiti MySql bazu ili neku drugu relacionu bazu.

3. (Zamisao zadatka)
- Imamo sistem za upravljanje transakcijama koji omogucava korisnicima da vrse novcane transakcije.
- Sistem koristi bazu podataka (InMemory) koja sadrzi informacije o korisnicima, njihovim racunima.
- Korisnici mogu da vrse transakcija, kao sto su uplate.
-Zadatak aplikacije je da omoguci korisnicima da vrse transakcije putem odgovarajuceg API endpointova. Korisnici mogu slati zahteve za izvrsavanje transakcija u odredjenoj valuti, sa odredjenim iznosom i sa odgovarajucim identifikatorima korisnika i racuna.
-Sistem treba da obezbedi sigurnost i pouzdanost u izvrsavanju transakcija, uz obezbedjivanje odgovarajuceg logovanja i pracenja aktivnosti radi lakseg otkrivanja gresaka ili problema u sistemu.
