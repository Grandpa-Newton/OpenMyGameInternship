namespace App.Scripts.Libs.Factory
{
    public interface IFactory<out T>
    {
        T Create();
    }

    public interface IFactory<out T, in TParam1>
    {
        T Create(TParam1 value);
    }

    public interface IFactory<out T, in TParam1, in TParam2>
    {
        T Create(TParam1 value, TParam2 value2);
    }
}