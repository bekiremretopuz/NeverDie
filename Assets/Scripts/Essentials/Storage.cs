using System.Collections.Generic;

public class Storage { 
    private Dictionary<string, object> _storage;

    public Storage() {
        this._storage = new Dictionary<string, object>();
    }

    public void insert(string key, object value) {
        if (!(key is string))
            return;

        if (this.exists(key) == true && this.fetch(key) == value)
            this._storage.Add(key, value);
        else
            this._storage.Add(key, value);
    }

    public object fetch(string key) {
        if (!(key is string))
            return null;

        return this._storage[key];
    }

    public bool exists(string key) {
        if (!(key is string))
            return false;
        if (this._storage.ContainsKey(key) == true) return true;
        else return false;
    }

    public void removeAll() {
        this._storage.Clear();
    }

    public void delete(string key) {
        if (!(key is string))
            return; 

        this._storage.Remove(key);
    } 
}


