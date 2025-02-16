import './App.css';
import { AppShell, createTheme, MantineProvider } from '@mantine/core';
import ResourceOverviewPage from './pages/ResourceOverviewPage';

function App() {
  return (
    <MantineProvider defaultColorScheme="dark">
      <AppShell header={{ height: 60 }} padding="md">
        <AppShell.Header>P.O. Interview</AppShell.Header>
        <AppShell.Main>
            <ResourceOverviewPage />
        </AppShell.Main>
      </AppShell>
    </MantineProvider>
  );
}

export default App;
