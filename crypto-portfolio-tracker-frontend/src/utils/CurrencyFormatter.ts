import { PricePrecision } from "./Constants";

const formatUsCurrency = (value: number): string => {
	return new Intl.NumberFormat('en-US', {
		style: 'currency',
		currency: 'USD',
		maximumFractionDigits: PricePrecision
	}).format(value);
}

export default formatUsCurrency