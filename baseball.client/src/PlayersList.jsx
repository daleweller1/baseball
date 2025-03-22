import React, { useEffect, useState } from "react";
import axios from "axios";
import PlayerCard from "./PlayerCard";
import EditPlayer from "./EditPlayer";
import PlayerBio from "./PlayerBio";
import "./PlayersList.css";

const PlayersList = () => {
    const [players, setPlayers] = useState([]);
    const [editingPlayer, setEditingPlayer] = useState(null);
    const [bioPlayer, setBioPlayer] = useState(null);

    useEffect(() => {
        axios.get("https://localhost:7094/api/baseball/players")
            .then(response => setPlayers(response.data))
            .catch(error => console.error("Error fetching players:", error));
    }, []);

    const handleEdit = (player) => {
        setEditingPlayer(player);
    };

    const handleSave = (updatedPlayer) => {
        setPlayers(players.map(p => p.id === updatedPlayer.id ? updatedPlayer : p));
        setEditingPlayer(null);
    };

    const handleCancel = () => {
        setEditingPlayer(null);
    };

    const handleBioClick = (player) => {
        setBioPlayer(player);
    };

    const handleCloseBio = () => {
        setBioPlayer(null);
    };

    return (
        <div className="players-container">
            {editingPlayer ? (
                <EditPlayer player={editingPlayer} onSave={handleSave} onCancel={handleCancel} />
            ) : (
                players.map(player => (
                    <PlayerCard
                        key={player.id}
                        player={player}
                        onEdit={handleEdit}
                        onBio={handleBioClick}
                    />
                ))
            )}

            {bioPlayer && (
                <PlayerBio player={bioPlayer} onClose={handleCloseBio} />
            )}
        </div>
    );
};

export default PlayersList;
