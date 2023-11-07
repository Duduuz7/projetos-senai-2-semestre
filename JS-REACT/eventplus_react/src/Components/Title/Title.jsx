import './Title.css'
import React from 'react';

const Title = (
    { titleText, additionalCLass = "", color = "" }
) => {
    return (
        <h1
            className={`title ${additionalCLass}`}
            style={{ color: color }}
        >
            {titleText}
            <hr 
            className='title__underscore'
            style={{ borderColor: color }} 
            />
        </h1>
    );
};

export default Title;
