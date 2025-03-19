import React, { useEffect, useState } from "react";
import axios from "axios";
import PlayerCard from "./PlayerCard";
import "./PlayersList.css";

const PlayersList = ({ onSelectPlayer }) => {
    const [players, setPlayers] = useState([]);

    useEffect(() => {
        axios.get("https://localhost:7094/api/baseball/players")
            .then(response => setPlayers(response.data))
            .catch(error => console.error("Error fetching players:", error));
    }, []);

    return (
        <div className="players-container">
            {players.map(player => (
                <PlayerCard key={player["Player name"]} player={player} onSelectPlayer={onSelectPlayer} />
            ))}
        </div>
    );
};

export default PlayersList;
