//using System;
//using DDD.Primitives.BoxUoMs;
//using DDD.Primitives.Misc;
//using NUnit.Framework;

//namespace UoMTests;

//public abstract class Box { }
//public class SmallBox : Box { }
//public class LargeBox : Box { }

//public class SelectorTests
//{
//    public class BoxSelector
//    {
//        public static Box? SelectBox(Dimensions dimensions)
//            => dimensions <= BoxUoM.Small.Dimensions() ? new SmallBox() :
//               dimensions <= BoxUoM.Large.Dimensions() ? new LargeBox() : null;

//        public static Box? Select(BoxUoM item)
//            => item switch
//            {
//                BoxUoM { Name: "Small Box" } => new SmallBox(),
//                BoxUoM { Name: "Large Box" } => new LargeBox(),
//                _ => null
//            };
//    }

//    [Test]
//    public void Select()
//    {
//        //Assert
//        Assert.AreEqual(BoxSelector.Select(BoxUoM.Small)!.GetType(), new SmallBox().GetType());
//    }

//}
