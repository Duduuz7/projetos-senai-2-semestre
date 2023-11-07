import React from 'react';
import Title from '../Title/Title';
import './VisionSection.css'

const VisionSection = () => {
    return (
        <section className='vision'>
            <div className='vision__box'>
                <Title
                    titleText={"Visão"}
                    color='white'
                    additionalCLass='vision__title'
                />
                <p className='vision__text'>Lorem ipsum dolor sit amet consectetur adipisicing elit. Delectus quas eveniet, provident assumenda, neque atque esse quidem reprehenderit quibusdam quaerat, voluptas ullam aliquam temporibus vitae nesciunt velit natus. Veniam, architecto Lorem ipsum dolor, sit amet consectetur adipisicing elit. Asperiores quaerat quisquam voluptatem impedit quod! Ratione, distinctio atque. Hic tenetur, suscipit, minima et nostrum quis ut, atque delectus distinctio obcaecati asperiores. </p>
            </div>
        </section>
    );
};

export default VisionSection;