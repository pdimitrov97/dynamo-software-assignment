import { IHistory } from "./IHistory";

export interface ISupportHistory<T> {
	history: IHistory<T>[];
}