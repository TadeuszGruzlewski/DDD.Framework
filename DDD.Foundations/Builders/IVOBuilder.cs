namespace DDD.Foundations;

public interface IVOBuilder<VO> where VO : ValueObject
{
    VO? Build(string objectName);
}
