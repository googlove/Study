import java.math.BigInteger;

class DiffieHellman
{
    private Primes primeNum = new Primes();

    public DiffieHellman()
    {
        PrimeNumber = primeNum.GetPrimeNumber();
    }

    public int PrimeNumber;

    public BigInteger GetKey(int g, int p, int a)
    {
        return new BigInteger(Integer.toString(g)).modPow(new BigInteger(Integer.toString(a)), new BigInteger(Integer.toString(p)));
    }

}
