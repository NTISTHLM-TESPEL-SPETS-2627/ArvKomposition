Console.WriteLine("Hello, World!");

GameObject character = new();


character.Components.Add(new HealthSystem(character));
character.Components.Add(new RegenSystem(character));

class RegenSystem : Component
{
  public RegenSystem(GameObject parent) : base(parent)
  {
  }

  public override void Update()
  {
    HealthSystem? s = Parent.GetComponent<HealthSystem>();

    if (s != null)
    {
      s.Hp++;
    }
  }
}

class HealthSystem : Component
{
  public int Hp;
  public int MaxHp;

  public HealthSystem(GameObject parent) : base(parent)
  {
  }

  public void Hurt(int amount) { }
  public void Heal(int amount) { }
}

class GameObject
{
  public List<Component> Components = [];

  public void Update()
  {
    foreach (Component c in Components)
    {
      c.Update();
    }
  }

  public T? GetComponent<T>() where T : Component
  {
    foreach (Component c in Components)
    {
      if (c is T) return (T?)c;
    }
    return null;
  }
}

class Component (GameObject parent)
{
  public GameObject Parent = parent;

  public virtual void Update() { }
}


// class Character
// {
//   public HealthSystem Health = new();
// }

// class Enemy
// {
//   public HealthSystem Health = new();
// }

// class Wall
// {
//   public HealthSystem Health = new();
// }

// class InventoryItem
// {
//   public int Weight;
// }

// class Weapon : InventoryItem
// {
//   public int MinDamage;
//   public int MaxDamage;
//   public virtual void Attack()
//   {
//     Console.WriteLine("WEAPON");
//   }
// }

// class Axe : Weapon
// {
//   public override void Attack()
//   {
//     base.Attack();
//     Console.WriteLine("AAAAAXE");
//   }
// }

// class Club : Weapon
// {

// }


// class Enemy
// {
//   public int Hp;
// }

// class Goomba : Enemy
// {

// }