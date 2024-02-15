import { DependencyList, useEffect, useRef } from "react";

function usePollingEffect(asyncCallback: () => {}, pollingInterval: number, dependencies: DependencyList = []) {
	const timeoutIdRef = useRef<NodeJS.Timeout | undefined>(undefined);

	useEffect(() => {
		let _stopped = false;

		const pollingCallback = () => {
			if (!_stopped) {
				timeoutIdRef.current = setTimeout(async () => {
					await asyncCallback();
					pollingCallback();
				}, pollingInterval * 1000);
			}
		};

		const startPolling = async () => {
			await pollingCallback();
		};

		const stopPolling = () => {
			clearTimeout(timeoutIdRef.current);
		};

		if (pollingInterval > 0) {
			startPolling();
		}
		else {
			stopPolling();
		}

		return () => {
			_stopped = true;
			stopPolling();
		};
	}, [...dependencies, pollingInterval]);
}

export default usePollingEffect;