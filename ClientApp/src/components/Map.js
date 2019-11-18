import React, { Component } from 'react';
import { ReactBingmaps } from 'react-bingmaps';
import { MdKeyboardArrowLeft, MdKeyboardArrowRight } from 'react-icons/md';

export class Map extends Component {
    static displayName = Map.name;

    constructor(props) {
        super(props);
        this.state = {
            pushPins: [],
        };
    }

    GetClick = (e) => {
        var house = [e.latitude, e.longitude];
        this.props.setHouse(house);
    }
        
    render() {
        return (
            <div className="Map">
                <ReactBingmaps
                    className="BingMap"
                    boundary={{
                        search: this.props.searchString,
                        option: {
                            entityType: 'none'
                        }
                    }}
                    mapOptions={ {
                        "showDashboard": false,
                    } }
                    bingmapKey="Ah_WM7V5cekTjFYg7mpxoZwBhbJos3PW9pm8UONTXjq7L9IKC4LH0yXwhWxunlCo"
                    center={[-30.048134, -51.156208]}
                    infoboxesWithPushPins={this.props.parentState.infoboxPushPins}
                    directions={this.props.parentState.directions}
                    getLocation={
                            { addHandler: "click", callback: this.GetClick.bind(this) }
                    }
                />
                <button className="toggleSideList" onClick={this.props.toggleSideList}>
                    {this.props.showSideList ? <MdKeyboardArrowLeft/> : <MdKeyboardArrowRight/>}
                </button>
            </div>
        );
    }
}
