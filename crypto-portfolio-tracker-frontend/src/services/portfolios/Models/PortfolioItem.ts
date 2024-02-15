import { ISupportCurrentValue } from "./ISupportCurrentValue";

export interface PortfolioItem extends ISupportCurrentValue {
	coin: string;
	amount: number;
	buyPrice: number;
	initialValue: number;
	currentPrice: number;
	currentValue: number;
	changePercentage: number;
}