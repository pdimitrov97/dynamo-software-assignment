import { AppBar, CssBaseline, Toolbar, Typography, styled } from '@mui/material';
import './App.css';
import PortfolioDashboardComponent from './components/PortfolioDashboardComponent/PortfolioDashboardComponent';

const MyThemeComponent = styled('div')(({ theme }) => ({
	backgroundColor: 'white',
	padding: theme.spacing(3)
}));


function App() {
	return (
		<div>
			<CssBaseline />

			<AppBar position="static">
				<Toolbar>
					<Typography variant="h6" noWrap>Dynamo Software Portfolio Assignment</Typography>
				</Toolbar>
			</AppBar>

			<main>
				<MyThemeComponent>
					<PortfolioDashboardComponent></PortfolioDashboardComponent>
				</MyThemeComponent>
			</main>
		</div>
	);
}

export default App;
