//using DDD.Foundations;

//namespace DDD.Examples.Baggage;

//public interface IBaggageAllowance
//{
//    private record class BaggageInvariant(List<InvariantError> Errors) : Invariant(Errors)
//    {
//        public bool IsAllowedNumber(List<BaggageItem> baggageItems, int allowedNumber)
//        {
//            var valid = baggageItems.Count <= allowedNumber;
//            if (!valid)
//                Errors.Add(new(InvariantErrorCode.OutsideRange, $"Number of baggage items exceeds the allowed limit."));
//            return valid;
//        }

//        public bool IsCabinAllowedWeight(List<BaggageItem> baggageItems, decimal allowedWeight)
//        {
//            var totalWeight = baggageItems.Sum(w => w.Weight);
//            var valid = totalWeight <= allowedWeight;
//            if (!valid)
//                Errors.Add(new(InvariantErrorCode.OutsideRange, $"Cabin baggage weight exceeds the allowed limit."));
//            return valid;
//        }

//        public bool IsCheckedAllowedWeight(BaggageItem baggageItem, decimal allowedWeight)
//        {
//            var valid = baggageItem.Weight <= allowedWeight;
//            if (!valid)
//                Errors.Add(new(InvariantErrorCode.OutsideRange, $"Baggage weight exceeds the allowed limit."));
//            return valid;
//        }
//    }

//    int NumberOfAccessories { get; }
//    int NumberOfHandBaggages { get; }
//    int NumberOfCheckedBaggages { get; }
//    decimal MaxWeightOfCabinBaggage { get; }
//    decimal MaxWeightOfCheckedSingleBaggage { get; }

//    bool IsBaggageAllowed(Baggage baggage, List<InvariantError> errors);
//}
