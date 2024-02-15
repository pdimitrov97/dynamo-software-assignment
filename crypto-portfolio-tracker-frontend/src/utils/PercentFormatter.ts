import { PercentagePrecision } from "./Constants";
import roundPrecise from "./NumberUtils";

const formatPercent = (value: number): string => {
	return `${roundPrecise(value, PercentagePrecision)}%`;
}

export default formatPercent;