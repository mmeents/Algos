using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Core.Tokens;

namespace Algos.Core.Models
{
  public class Items : ConcurrentDictionary<int, Item> {
    private readonly object _lock = new object();
    public Items() : base() { }
    public Items(IEnumerable<Item> items) : base() {
      AsList = items;
    }
    public virtual Boolean Contains(int id) {
      try {
        return base.ContainsKey(id);
      } catch {
        return false;
      }
    }
    public virtual new Item this[int id] {
      get { return Contains(id) ? base[id] : null; }
      set { if (value != null) { base[id] = value; } else { Remove(id); } }
    }
    public virtual void Remove(int id) { if (Contains(id)) { _ = base.TryRemove(id, out _); } }

    public IEnumerable<Item> GetChildrenItems(int id) {
      return this.Select(x => x.Value).Where(x => x.OwnerId == id).OrderBy(x => x.ItemRank);
    }
    public int GetNextId() {
      return this.Select(x => x.Value.Id).DefaultIfEmpty(0).Max() + 1;
    }

    public void Add(Item item) {
      lock (_lock) {
        if (item.Id == 0) {
          item.Id = GetNextId();
        }
        base[item.Id] = item;     
      }
    }

    public IEnumerable<Item> AsList {
      get {
        lock (_lock) {
          return base.Values.ToList();
        }
      }
      set {
        lock (_lock) {
          base.Clear();          
          foreach (var item in value) {
            Add(item);
          }
        }
      }
    }
  }
}
