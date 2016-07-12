using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADReports
{
    class MapLinker<T> where T : class
    {

        private Dictionary<string, List<T>> _origen;
        private Dictionary<string, List<T>> _destino;

        public MapLinker(Dictionary<string, List<T>> origen, Dictionary<string, List<T>> destino)
        {
            this._origen = origen;
            this._destino = destino;
        }

        public void moveToDestino(string key, T objeto)
        {
                List<T> lista_destino = this._destino[key];
                List<T> lista_origen = this._origen[key];
                
                lista_destino.Add(objeto);
                lista_origen.Remove(objeto);
            
        }
        public void moveToOrigen(string key, T objeto)
        {

                List<T> lista_destino = this._destino[key];
                List<T> lista_origen = this._origen[key];

                lista_origen.Add(objeto);
                lista_destino.Remove(objeto);
            
        }

        public List<T> getListOrigen(string key)
        {
            return this._origen[key];
        }

        public List<T> getListDestino(string key)
        {
            return this._destino[key];
        }

        public Dictionary<string, List<T>> getMapOrigen()
        {
            return this._origen;
        }
        public Dictionary<string, List<T>> getMapDestino()
        {
            return this._destino;
        }
    }
}
