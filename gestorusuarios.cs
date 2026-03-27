
namespace Tiendaconsola
{
    public class gestorusuarios
    {
        private usuario[] usuarios = new usuario[10];
        private int cantidad = 0;

        public gestorusuarios()
        {
            agregarusuario(new usuario("rey", "1234", new rol("Administrador")));
            agregarusuario(new usuario("david", "0000", new rol("Cliente")));
        }

        public void agregarusuario(usuario u)
        {
            if (cantidad < 10)
            {
                usuarios[cantidad] = u;
                cantidad++;
            }
        }

        public usuario login(string usr, string pwd)
        {
            for (int i = 0; i < cantidad; i++)
            {
                if (usuarios[i].getusername() == usr && usuarios[i].validarpassword(pwd))
                {
                    return usuarios[i];
                }
            }
            return null;
        }

        public int cantidadusuarios() { return cantidad; }
        public usuario getusuario(int pos) { return usuarios[pos]; }

        private int buscarindice(string usr)
        {
            for (int i = 0; i < cantidad; i++)
            {
                if (usuarios[i].getusername() == usr) return i;
            }
            return -1;
        }

        public bool actualizarusuario(string usr, string nuevapassword)
        {
            int idx = buscarindice(usr);
            if (idx != -1)
            {
                usuarios[idx].setpassword(nuevapassword);
                return true;
            }
            return false;
        }

        public bool eliminarusuario(string usr)
        {
            int idx = buscarindice(usr);
            if (idx != -1)
            {
                for (int i = idx; i < cantidad - 1; i++)
                {
                    usuarios[i] = usuarios[i + 1];
                }
                usuarios[cantidad - 1] = null;
                cantidad--;
                return true;
            }
            return false;
        }
    }
}git push -u origin main -f