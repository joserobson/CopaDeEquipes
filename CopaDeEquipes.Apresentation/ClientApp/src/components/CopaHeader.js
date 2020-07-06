import React, { Component } from 'react';
import './CopaHeader.css';

export class CopaHeader extends Component {

    constructor(props) {

        super(props);
        this.state = {
            titulo: props.titulo,
            subTitulo: props.subTitulo
        };

    }

    componentWillReceiveProps(props) {
        this.setState({
            titulo: props.titulo,
            subTitulo: props.subTitulo
           }
        );
    }

    render() {
        return (
            <div id="copaHeader" className='row'>                
                <div align='center'>
                    <h4>Copa</h4>
                </div>
                <div align='center'>
                    <h2>{this.state.titulo}</h2>
                </div>
                <div align='center'>
                    <h5>{this.state.subTitulo}</h5>
                </div>
            </div>
        );
    }

    
}