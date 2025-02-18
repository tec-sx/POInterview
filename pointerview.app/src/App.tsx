import './App.css';
import { AppShell, MantineProvider } from '@mantine/core';
import { Notifications } from '@mantine/notifications';
import ResourceOverviewPage from './pages/ResourceOverviewPage';

function App() {
  return (
    <MantineProvider defaultColorScheme="light">
      <Notifications />
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
