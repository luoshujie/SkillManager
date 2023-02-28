/// <summary>
/// 角色数据基类
/// </summary>
public class RoleBaseData
{
    public int hp;
    public int maxHp;
    public float speed;
    public int attack;
    public int defense;

    public RoleBaseData(int maxHp, int hp, float speed, int attack, int defense)
    {
        this.maxHp = maxHp;
        this.hp = hp;
        this.speed = speed;
        this.attack = attack;
        this.defense = defense;
    }
}
