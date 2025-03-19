import { useState } from "react";
import "./App.css";
import PlayersList from "./PlayersList";
import PlayerDetails from "./PlayerDetails";
import EditPlayer from "./EditPlayer";

function App() {
    const [selectedPlayer, setSelectedPlayer] = useState(null);
    const [isEditing, setIsEditing] = useState(false);

    const handleSelectPlayer = (player) => {
        setSelectedPlayer(player);
        setIsEditing(false); // Ensure the edit form is hidden when selecting a new player
    };

    const handleEditClick = () => {
        setIsEditing(true);
    };

    const handleSave = (updatedPlayer) => {
        setSelectedPlayer(updatedPlayer);
        setIsEditing(false);
    };

    return (
        <div className="App">
            <h1>Baseball Players</h1>
            <div className="container">
                <PlayersList onSelectPlayer={handleSelectPlayer} />
                {isEditing ? (
                    <EditPlayer player={selectedPlayer} onSave={handleSave} />
                ) : (
                    <PlayerDetails player={selectedPlayer} onEdit={handleEditClick} />
                )}
            </div>
        </div>
    );
}

export default App;
