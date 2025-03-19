import React, { useState } from "react";
import axios from "axios";

const EditPlayer = ({ player, onSave }) => {
    const [editedPlayer, setEditedPlayer] = useState(player);

    const handleChange = (e) => {
        setEditedPlayer({ ...editedPlayer, [e.target.name]: e.target.value });
    };

    const handleSubmit = () => {
        axios.put(`http://localhost:5000/api/baseball/players/${player.id}`, editedPlayer)
            .then(() => onSave(editedPlayer))
            .catch(error => console.error("Error updating player:", error));
    };

    return (
        <div>
            <h2>Edit Player</h2>
            <input name="name" value={editedPlayer.name} onChange={handleChange} />
            <input name="hits" type="number" value={editedPlayer.hits} onChange={handleChange} />
            <button onClick={handleSubmit}>Save</button>
        </div>
    );
};

export default EditPlayer;
