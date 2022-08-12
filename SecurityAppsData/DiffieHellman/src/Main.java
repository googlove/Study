import java.io.FileWriter;
import java.io.IOException;
import java.math.BigInteger;

class Main
{

    public static void main(String[] args)
    {
        Primes primeNum = new Primes();

        int g = primeNum.GetPrimeNumber();
        int p = primeNum.GetPrimeNumber();


        Abonent alice = new Abonent("Alice", g, p);
        Abonent bob = new Abonent("Bob", g, p);


        BigInteger keyAlice = alice.GetKey(bob.public_M);
        BigInteger keyBob = bob.GetKey(alice.public_M);

        System.out.println("Кінцевий ключ Аліси: " + keyAlice + " Кінцевий ключ Боба: " + keyBob);

        try(FileWriter writer = new FileWriter("result.txt", true)) {

            writer.append("Кінцвий ключ Аліси = ");
            writer.write(String.valueOf(keyAlice));
            writer.append('\n');

            writer.append("Кінцвий ключ Боба = ");
            writer.write(String.valueOf(keyBob));

            writer.append("\n___________________________");
            writer.append('\n');

        }

        catch (IOException ex) {
            System.out.println(ex.getMessage());        }
    }
}
