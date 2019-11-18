import React, { Component } from 'react';
import { FaSearchLocation, FaMapPin } from 'react-icons/fa';

import '../styles/sideList.css';

export class SchoolsList extends Component {
    static displayName = SchoolsList.name;

    constructor(props) {
        super(props);
        this.state = {
            }
        this.aplicaDirection = this.aplicaDirection.bind(this);
    }

    

    aplicaDirection(location1, location2) {
        this.props.aplicaDirection(location1, location2);
    }

    searchEngine = (e) => {
        var searchString = document.getElementById("searchString").value;
        this.props.searchEngine(searchString)
        e.preventDefault();
    }

    renderSchoolsTable(schools) {
        return (
            <>
                <table className='school_table'>
                    <thead>
                        <tr>
                            <th>Name</th>
                            <th>Distance</th>
                        </tr>
                    </thead>
                    <tbody>
                        {schools.map(schools =>
                                <tr key={schools.id} >
                                <td>{schools.name} ({schools.abr_nome})</td>
                                <td>{schools.distance === "--" ? schools.distance : schools.distance.toFixed(1)} km</td>
                                <td><FaMapPin className="tablePin" onClick={() => this.aplicaDirection(this.props.House, schools.location)} /></td>
                                </tr>
                            )
                        }
                    </tbody>
                </table>
            </>
        );
    }

    render () {
        let contents = this.props.parentState.loading
            ? <p><em> Loading... </em></p>
            : this.renderSchoolsTable(this.props.parentState.schoolsList)
        return (
            <div className="SideList">
                <form className='findSchool' onSubmit={this.searchEngine}>
                    <input id="searchString"
                        className='findSchool'
                        type='text'
                        placeholder='Where is your house?'
                        onChange={this.searchEngine}
                        value={this.props.searchString}
                    />
                    <button type="button" className="SearchButton" onClick={() => this.props.calcDistance()}><FaSearchLocation /></button>
                </form>
                {contents}
            </div>
        );
    }
}
