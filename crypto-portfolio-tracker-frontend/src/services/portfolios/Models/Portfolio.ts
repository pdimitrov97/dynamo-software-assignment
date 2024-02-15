import { ISupportCurrentValue } from "./ISupportCurrentValue";
import { PortfolioItem } from "./PortfolioItem";

export interface Portfolio extends ISupportCurrentValue {
	items: PortfolioItem[];
	initialValue: number;
	currentValue: number;
	overallChangeValue: number;
	overallChangePercentage: number;
}