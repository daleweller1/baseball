import { useState } from "react";
import "./App.css";
import PlayersList from "./PlayersList";
import EditPlayer from "./EditPlayer";

function App() {
    const [selectedPlayer, setSelectedPlayer] = useState(null);

    return (
        <div className="App">
            <h1>Baseball Players</h1>
            <div className="container">
                {selectedPlayer ? (
                    <EditPlayer
                        player={selectedPlayer}
                        onSave={() => setSelectedPlayer(null)}  // Return to list after saving
                        onCancel={() => setSelectedPlayer(null)} // Return to list when canceling
                    />
                ) : (
                    <PlayersList onSelectPlayer={setSelectedPlayer} />
                )}
            </div>
        </div>
    );
}

export default App;
