using Majorsoft.Blazor.Components.Core.Extensions;
using Majorsoft.Blazor.Components.Maps.Google;
using Majorsoft.Blazor.Components.Maps;

namespace Ixhuatlan.Caracolillo.Frontend.RazorViews.Pages;

public partial class Home
{
    private readonly string _googleMapsApiKey = "AIzaSyCNGDDCBXfXGJV0zWe3LcZN9lTPbX9bCc4";

    private GoogleMap _googleMap;
    private readonly GeolocationData _jsMapCenter = new GeolocationData(19.05075057931591, -96.98396677396086);
    private readonly int _jsMapControlSize = 38;
    private readonly byte _jsMapZoomLevel = 10;
    private readonly bool _jsMapCenterCurrentLocation = true;
    private readonly GoogleMapTypes _jsMapType = GoogleMapTypes.Roadmap;
    private readonly byte _jsTilt = 0;
    private readonly int _jsHeading = 0;
    private readonly bool _jsMapAnimateCenterChange = true;
    private readonly bool _jsClickableIcons = true;
    private readonly bool _jsDisableDefaultUI = false;
    private readonly bool _jsDisableDoubleClickZoom = false;
    private readonly bool _jsFullscreenControl = true;
    private readonly GoogleMapControlPositions _jsFullscreenControlPositon = GoogleMapControlPositions.TOP_RIGHT;
    private readonly GoogleMapGestureHandlingTypes _jsGestureHandling = GoogleMapGestureHandlingTypes.Auto;
    private readonly bool _jsKeyboardShortcuts = true;
    private readonly bool _jsMapTypeControl = true;

    private readonly GoogleMapTypeControlOptions _jsMapTypeControlOptions = new()
    {
        MapTypeControlStyle = GoogleMapTypeControlStyles.DROPDOWN_MENU
    };

    private readonly bool _jsRotateControl = true;
    private readonly bool _jsScaleControl = true;
    private readonly bool _jsStreetViewControl = true;
    private readonly bool _jsZoomControl = true;

    private readonly List<GoogleMapCustomControl> _jsCustomControls = new();
    private readonly ObservableRangeCollection<GoogleMapMarker> _jsMarkers = new();
    private ObservableRangeCollection<GoogleMapMarker> _jsMarkersTmp = new();
}