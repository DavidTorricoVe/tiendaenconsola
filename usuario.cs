namespace Tiendaconsola
{
    public class usuario
    {
        private string username;
        private string password;
        private rol tiporol;

        public usuario(string usr, string pwd, rol r)
        {
            username = usr;
            password = pwd;
            tiporol = r;
        }

        public string getusername() { return username; }
        
        public bool validarpassword(string pwd) { return password == pwd; }
        
        public rol getrol() { return tiporol; }

        public void setpassword(string p) { password = p; }
    }
}
