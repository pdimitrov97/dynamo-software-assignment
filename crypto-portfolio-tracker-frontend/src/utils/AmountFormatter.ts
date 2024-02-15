import { AmountPrecision } from "./Constants";
import roundPrecise from "./NumberUtils";

const formatAmount = (value: number): number => {
	return roundPrecise(value, AmountPrecision);
}

export default formatAmount;