import React, { useState } from 'react';

export const FormTodo = (props) => {
    
    const [state, setState] = useState({
        name : ""
    });

    
    function handleChange(e) {
        setState({...state, name : e.target.value})
    }

    function handleSubmit(e) {
        e.preventDefault();

        if (state.name.length < 1) {
            alert("No se aceptan caracteres en blanco");
        }
        console.log("Ejecutando");
        props.onSubmit(state);
        
    }


   
    return (
        <form onSubmit={ handleSubmit }>
            <div className="mb-3">
                <label htmlFor="exampleFormControlInput1" className="form-label">TO DO</label>
                <input
                    type="text"
                    className="form-control"
                    id="exampleFormControlInput1"
                    placeholder="My Todo"
                    onChange={handleChange}
                    value={ state.name}
                />
            </div>
            <button type="submit" className = "btn btn-primary">Submit</button>
        </ form>
    )
}