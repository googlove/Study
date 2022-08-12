import java.math.BigInteger;

class Abonent
{
    private DiffieHellman diffieHellman = new DiffieHellman();
    private int g;
    private String sms;
    public String name;
    private int p;

    public BigInteger public_M;
    private int secret_key;


    public Abonent(String name, int g, int p, String sms)
    {
        this.name = name;
        this.p = p;
        this.sms = sms;
        this.g = g;
        secret_key = diffieHellman.PrimeNumber;
        public_M = diffieHellman.GetKey(this.g, this.p, secret_key);
    }

    public Abonent(String name, int randomizer, int primemod) {

        this(name, randomizer, primemod, "");
    }

    public BigInteger GetKey(BigInteger public_M)
    {
        BigInteger g = public_M.pow(secret_key);
        BigInteger K = g.mod(new BigInteger(Integer.toString(p)));

        return K;
    }

}
