// Define some variables used to remember state.
var playlistId, nextPageToken, prevPageToken;

// After the API loads, call a function to get the uploads playlist ID.
function handleAPILoaded() {
  requestUserSubscriptions();
}

// Call the Data API to retrieve the playlist ID that uniquely identifies the
// list of videos uploaded to the currently authenticated user's channel.
function requestUserSubscriptions(nextPageToken) {
  // See https://developers.google.com/youtube/v3/docs/channels/list
  var request = gapi.client.youtube.subscriptions.list({
    mine: true,
    part: 'snippet',
    maxResults: 50
  });

  if (nextPageToken) {
    request.pageToken = nextPageToken;
  }

  request.execute(function(response) {
    nextPageToken = response.result.nextPageToken;

    var mySubscriptions = response.result.items;
    if (mySubscriptions) {
      $.each(mySubscriptions, function(index, item) {
        displayResult(item.snippet);
      });
    } else {
      $('#subscriptions-container').html('Sorry you have no subscriptions');
    }
  });
}

// Create a listing for a video.
function displayResult(videoSnippet) {
  var title = videoSnippet.title;
  var thumbnail = videoSnippet.thumbnails.high.url;
  //$('#subscriptions-container').append('<div class="col-xs-6 col-sm-4 col-lg-2"><h3 class="text-center">' + title + '</h3><img class="img-responsive center-block" src="' + thumbnail + '" /></div>');
  $('#subscriptions-container').append('<div class="row"> \
			<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12"> \
				<div class="cuadro_intro_hover"> \
					<p style="text-align:center; margin-top:20px;"> \
						<img src="' + thumbnail + '" class="img-responsive" alt="">\
					</p>\
					<div class="caption">\
						<div class="blur"></div>\
						<div class="caption-text">\
							<h3 style="padding:10px;">' + title + '</h3>\
							<p>Some Info Text</p>\
						</div>\
					</div>\
				</div>\
			</div>\
		</div>');
}
