using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PoolingManager2 : MonoBehaviour
{
    

    
    [Serializable]
    public class PooledItems //Esta clase servirá para identificar cada lista
    {
        public string Name; //El identificador de la lista 
        public GameObject objectToPool; //El objeto que queremos multiplicar
        public int amount; //La cantidad de instancias iniciales
    }

    private static PoolingManager2 _instance;
    public static PoolingManager2 Instance
    {
        get //Para asegurarnos de que se crea la instancia antes que nada
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<PoolingManager2>();
            }
            return _instance;
        }
    }
    [SerializeField]
    private List<PooledItems> pooledLists = new List<PooledItems>();

    private Dictionary<string, List<GameObject>> _items = new Dictionary<string, List<GameObject>>();

    // Start is called before the first frame update
     void Awake()
    {
        for(int i =0;i < pooledLists.Count ;i++) //Para cada lista de objetos 
        {
            PooledItems l = pooledLists[i];
            _items.Add(l.Name, new List<GameObject>()); //Creamos una entrada en el dictionary
             for (int j=0; j<l.amount;j++)
            {
                GameObject tmp;
                tmp = Instantiate(l.objectToPool); //Aquí creamos la copia
                tmp.SetActive(false); //la desactivamos
                _items[l.Name].Add(tmp);  //y la añadimos a la llista 

            }

        }
    }
    public GameObject GetPooledObject (string name)
    {
       // Debug.Log("xs");
        List<GameObject> tmp=_items[name];
        for (int i=0; i<tmp.Count;i++)
        {
            if(!tmp[i].activeInHierarchy)
            {
                return tmp[i];
            }
        }
        return null;

    }
}

