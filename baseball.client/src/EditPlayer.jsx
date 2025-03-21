import React, { useState } from "react";
import axios from "axios";
import "./EditPlayer.css"; // Ensure we have styles for the modal

const EditPlayer = ({ player, onSave, onCancel }) => {
    const [editedPlayer, setEditedPlayer] = useState({ ...player });

    const handleChange = (e) => {
        setEditedPlayer({ ...editedPlayer, [e.target.name]: e.target.value });
    };

    const handleSubmit = async (e) => {
        e.preventDefault();
        try {
            await axios.put(`https://localhost:7094/api/baseball/players/${editedPlayer.id}`, editedPlayer);
            onSave(editedPlayer); // Close modal after saving
        } catch (error) {
            console.error("Error updating player:", error);
        }
    };

    return (
        <div className="modal-overlay" onClick={onCancel}>
            <div className="modal" onClick={(e) => e.stopPropagation()}>
                <h2>Edit Player</h2>
                <div className="modal-content">
                    <form onSubmit={handleSubmit} className="edit-player-form">
                        <div className="scrollable-content">
                            {Object.keys(editedPlayer).map((key) => (
                                key === "id" ? null : ( // Prevent editing the ID
                                    <div className="form-group" key={key}>
                                        <label>{key.replace(/_/g, ' ')}:</label>
                                        <input
                                            name={key}
                                            value={editedPlayer[key]}
                                            onChange={handleChange}
                                        />
                                    </div>
                                )
                            ))}
                        </div>
                        <div className="button-group">
                            <button type="button" className="cancel-btn" onClick={onCancel}>Cancel</button>
                            <button type="submit" className="save-btn">Save</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    );
};

export default EditPlayer;
