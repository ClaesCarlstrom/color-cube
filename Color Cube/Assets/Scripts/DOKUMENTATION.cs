using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DOKUMENTATION : MonoBehaviour {

	/*
     * Jobbar just nu med:
     * 
     * 
     * När kuben landar på sidan så blir det collision men ypositionen som sätts är högre än när den har lagt sig tillrätta
     * Därför tror unity att kuben faller
     * Jag har satt en falling offset som gör att kuben inte räknas som att den faller såvida den inte är några fler steg under ypositionen
     * Men då kan man fuska och fortfarande hoppa om man flyger ner från plattformen men inte ännu har hunnit hamna under ypositionen
     * 
     * 
     * 
     * 
     *  Finjustera massan så att kuben inte flyger iväg för lätt men heller inte blir för trög.
     *  Tänk på att justera jumpforce därefter
     *  
     *  Kanske minska triggers så att den inte råkar stöta i fel färg... 
     *  
     *  Jobba med space-knappen för hopp och rotation så att man inte roterar så fort man hoppar - FIXAT!
     *  
     *  OCH någon konstig bugg där kuben råkar stöta i en plattform så tror det nog att den är i
     *  luften men den har redan landat på en annan platform, och därför så vill den inte hoppa utan
     *  bara rotera.... tror jag.
     *  
     *
     * 
     *  Testning av Kennie:
     *  Kul och beroendeframkallande
     *  Bra musik - enkelt atmosfäriskt, ambient
     *  Bakgrunden bra för att den inte var i vägen
     *  Kuben måste ha de egenskaper som förväntas av en kub
     *  Bara space som hopp
     *  
     *  Svarta är väldigt svåra, kanske ska de vara vertikala istället för horisontella? 
     *  Då blockas en annan färg en den spelaren har nedåt och ska landa med.
     *  
     *  Levelbyggande: 
     *  Jobba på att låta spelaren alltid kunna se vad som kommer om man är riktigt
     *  försiktig och smyger ut på kanten så kan man se längst bort på skärmen något skymta
     *  Så man inte måste dö för att se var man ska hoppa
     *  
     *  Vissa levels kan ha flera nivåer så att man kan falla ner till 
     *  
     *  En värld: Allt vänds upp och ner
     *  
     *  En annan värld: Lek med massan och gravitationen
     *  
     *  
     *  
     *  Tutorialbanan behöver bli lättare och bättre
     *  
     */
}
