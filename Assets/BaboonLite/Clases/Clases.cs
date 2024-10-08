using System;
using System.Collections.Generic;
using UnityEngine;

namespace BaboOnLite
{
    //CLASES 

    //Clases que se usan en el componenete CONTROLADOR
    #region controlador

    //PUBLICAS
    [Serializable]
    public class Movimiento
    {
        public float duracion;
        public Vector3 destino;
        public AnimationCurve curva;

        public Movimiento(float duracion, Vector3 destino, AnimationCurve anim = null)
        {
            this.duracion = duracion;
            this.destino = destino;
            this.curva = anim ?? AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);
        }
    }
    [Serializable]
    public class Rotacion
    {
        public float duracion;
        public Quaternion destino;
        public AnimationCurve curva;

        //Elegir solo la rotacion z. 2D
        public Rotacion(float duracion, int destino, AnimationCurve anim = null)
        {
            this.duracion = duracion;
            this.destino = Quaternion.Euler(0, 0, destino);
            this.curva = anim ?? AnimationCurve.EaseInOut(0.0f, 0.0f, 1.0f, 1.0f);
        }
        //Elegir el Quaternion. 3D
        public Rotacion(float duracion, Quaternion destino, AnimationCurve anim = null)
        {
            this.duracion = duracion;
            this.destino = destino;
            this.curva = anim ?? AnimationCurve.Linear(0f, 0f, 1f, 1f);
        }
    }

    //PRIVADAS
    public class Trans
    {
        public List<Transform> trans = new List<Transform>();
        public List<RectTransform> rect = new List<RectTransform>();
    }
    #endregion

    //Clases que se usan en el componenete LIMITES
    #region limites
    [System.Serializable]
    public class Manual
    {
        [SerializeField] internal Transform izquierdo, derecho;
    }
    #endregion

    //DICCIONARIO 
    #region diccionario
    [Serializable]
    public class DictionaryBG<T>
    {
        //VARIABLES
        [SerializeField] public List<Elementos> data = new List<Elementos>();

        //Contenido que va en la lista elementos
        #region contenido   
        [Serializable]
        public class Elementos
        {
            [SerializeField] public string indice;
            [SerializeField] public T valor;

            public Elementos(string indice, T valor)
            {
                this.valor = valor;
                this.indice = indice;
            }
        }
        #endregion

        //Coger informacion del diccionario
        #region get
        //Usando un indice string
        public T Get(string indice)
        {
            T valor = default(T);

            data.ForEach((elemento) =>
            {
                if (indice.ToLower() == elemento.indice.ToLower())
                {
                    valor = elemento.valor;
                }
            });

            return valor;
        }
        //Usando un indice int
        public T Get(int indice) => data[indice].valor;
        #endregion

        //A�ade elementos al diccionario
        #region add
        public void Add(string indice, T valor)
        {
            data.Add(new Elementos(indice, valor));
        }
        #endregion

        //Te dice si contiene un valor dentro del diccionario
        #region inside
        //Usando un indice string
        public bool Inside(string indice)
        {
            bool dentro = false;
            data.ForEach((element) =>
            {
                if (indice.ToLower() == element.indice.ToLower())
                {
                    dentro = true;
                }
            });
            return dentro;
        }
        //Usando un indice int
        public bool Inside(int indice)
        {
            return (indice >= 0 && indice < data.Count);
        }
        #endregion

        //Te da todos los elementos
        #region foreach
        public void ForEach(Action<string, T> func)
        {
            data.ForEach((elemento) =>
            {
                func(elemento.indice, elemento.valor);  
            });
        }
        #endregion

        //Te da la lonngitud de la lista
        #region length
        public int Length() => data.Count;
        #endregion

    }
    #endregion
}
