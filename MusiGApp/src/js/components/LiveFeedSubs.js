import React from 'react';

export default class LiveFeedSubs extends React.Component {
    render() {

        return (
            <div class="row">

                    {this.props.subscriptions.items.map(function(sub) {
                        console.log(sub);
                        return (
                          <div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">
                            <div class="grid">
                                <figure class="effect-zoe">
                                    <img class="img-responsive" src="http://www.tabletwallpapers.org/download/thumbnails/peak-wallpaper.png" alt={sub.snippet.title} />
                                    
                                </figure>
                                <h2>{sub.snippet.title}</h2>
                            </div>
                            </div>
                        )
                    })}

            </div>
        );
    }
}
