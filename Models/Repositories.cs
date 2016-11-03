using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
//yeaux
public interface HasId {
    int Id ();
}

public interface IRepository<T> { 
    void Create(T item);
    IEnumerable<T> Read();
    T Read(int id);
    voidUpdate(T item);
    T Delete(int id);
}

public class Repo<T> : IRepository<T> where T : HasId {

    private static ConcurrentDictionary<int, T> words = new ConcurrentDictionary<int, T>();
    }

    public void Create(T item){
        words[new Random.Next()] = item;
    }

    public IEnumerable<T> Read(){
        return words.Values;
    }
    
    public T Read(int id){
        return words[id];
    }
    
    public void Update(T item){
       words[item.GetId()] = item;
    }
    
    public T Delete(int id){
        T item;
        if(item != null) {
            words.TryRemove(id, item);
            db.SaveChanges();
            return item;
        }
        return null;
    }

}
