import { PercentagePrecision, PricePrecision } from "../../../utils/Constants";
import roundPrecise from "../../../utils/NumberUtils";
import { IHistory } from "./IHistory";
import { ISupportCurrentValue } from "../Models/ISupportCurrentValue";
import { ISupportChangeSinceOpen } from "./ISupportChangeSinceOpen";

export class ChangeSinceOpenHelper {
	public static calculateChangeSinceOpen(history: IHistory<ISupportCurrentValue>[]): ISupportChangeSinceOpen {
		if (!history || history.length === 0) {
			return {
				changeValueSinceOpen: 0,
				changePercentageSinceOpen: 0
			};
		}

		const firstValue = history[0].item?.currentValue;
		const lastValue = history[history.length - 1].item?.currentValue;

		if (!firstValue || firstValue === 0 || !lastValue) {
			return {
				changeValueSinceOpen: 0,
				changePercentageSinceOpen: 0
			};
		}

		const change = (lastValue - firstValue);
		const changePercentage = change / firstValue * 100;

		return {
			changeValueSinceOpen: roundPrecise(change, PricePrecision),
			changePercentageSinceOpen: roundPrecise(changePercentage, PercentagePrecision)
		};
	}
}