import { FC, useEffect, useRef, useState } from 'react';
import { httpService } from '../../services/portfolios/PortfolioService';
import FileUploadComponent from '../FileUploadComponent/FileUploadComponent';
import PortfolioComponent from '../PortfolioComponent/PortfolioComponent';
import usePollingEffect from '../../utils/PollingUtils';
import { Box, Button, TextField, Typography } from '@mui/material';
import { PortfolioViewModel } from '../../services/portfolios/ViewModels/PortfolioViewModel';
import { PortfolioViewModelHelper } from "../../services/portfolios/ViewModels/PortfolioViewModelHelper";
import { Portfolio } from '../../services/portfolios/Models/Portfolio';

const PortfolioDashboardComponent: FC = () => {

	const [file, setFile] = useState<File>(null);
	const [portfolio, setPortfolio] = useState<Portfolio>(null)
	const [portfolioViewModel, setPortfolioViewModel] = useState<PortfolioViewModel>(null);
	const [errorMessage, setErrorMessage] = useState<string | null>(null);
	const [pollingInterval, setPollingInterval] = useState<number>(5);

	const portfolioViewModelRef = useRef<PortfolioViewModel>(portfolioViewModel);

	const handleUpload = async (file: File) => {
		if (!file) {
			return;
		}

		setFile(file);
	};

	const handleUploadNewPortfolio = () => {
		setFile(null);
		setPortfolio(null);
		setPortfolioViewModel(null);
		setErrorMessage(null);
	}

	const handlePollingIntervalChange = (value: number | string) => {
		value = Number(value) || 0;
		setPollingInterval(value);
	}

	const loadPortfolioRevisions = async () => {
		if (!file) {
			return;
		}

		setErrorMessage(null);
		httpService.calculateValue(file)
			.then(result => {
				const updatedPortfolio = PortfolioViewModelHelper.updatePortfolioViewModel(portfolioViewModelRef.current, result);
				setPortfolioViewModel(updatedPortfolio);
			})
			.catch(error => {
				setErrorMessage(error.message);
			});
	}

	useEffect(() => {
		if (!file) {
			return;
		}

		httpService.calculateValue(file)
			.then(result => {
				setPortfolio(result);

				const viewModel = PortfolioViewModelHelper.createPortfolioViewModel(result, file.name);
				setPortfolioViewModel(viewModel);
			})
			.catch(error => {
				setErrorMessage(error.message);
			});
	}, [file]);

	useEffect(() => {
		portfolioViewModelRef.current = portfolioViewModel;
	}, [portfolioViewModel])

	// Polling interval is in minutes
	usePollingEffect(loadPortfolioRevisions, pollingInterval * 60, [portfolio]);

	return (
		<div>
			{!portfolioViewModel &&
				<div>
					<Typography variant="h6" noWrap>Welcome to Portfolio Checker!</Typography>
					<Typography paragraph={true}>Start by choosing a portfolio file and uploading it.</Typography>
					<FileUploadComponent uploadButtonName="Upload Portfolio" onUploadClicked={handleUpload}></FileUploadComponent>
				</div>
			}

			{portfolioViewModel &&
				<div>
					<Box component="div">
						<Button variant="contained"
							color="primary"
							component="span"
							onClick={handleUploadNewPortfolio}>Upload New Portfolio</Button>
					</Box>

					<TextField id="pollingInterval"
						type="number"
						label="Polling Interval"
						variant="outlined"
						value={pollingInterval}
						sx={{ mt: 2, mb: 2 }}
						onChange={e => handlePollingIntervalChange(e.target.value)} />

					<PortfolioComponent portfolioViewModel={portfolioViewModel}></PortfolioComponent>
				</div>
			}

			{errorMessage &&
				<div>There was an error parsing the portfolio file: <b>{errorMessage}</b></div>
			}
		</div>
	);
};

export default PortfolioDashboardComponent;