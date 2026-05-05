# Love Portal 💝

A beautiful, responsive Progressive Web App (PWA) built with ASP.NET Core Minimal APIs. Designed for both iOS and Android with offline support.

## Features

- ✨ **Progressive Web App** - Install on home screen, works offline
- 📱 **Mobile-First Design** - Optimized for all devices (iOS, Android)
- 🍎 **iOS Support** - Full PWA support with notch handling and safe-area support
- 🤖 **Android Support** - Responsive design, shortcuts, and offline caching
- 💾 **Service Worker** - Network-first strategy with offline fallback
- 🎨 **Beautiful UI** - Elegant, romantic aesthetic with animations
- ⚡ **Fast Performance** - Optimized for Railway deployment

## Installation

### Local Development

```bash
dotnet restore
dotnet run
```

Open browser to `http://localhost:8080`

### Install as PWA

#### iOS
1. Open in Safari
2. Tap Share button
3. Select "Add to Home Screen"
4. Tap "Add"

#### Android
1. Open in Chrome
2. Tap menu (three dots)
3. Tap "Install app"
4. Confirm installation

## Deployment to Railway

### Prerequisites
- Railway account (free tier available at railway.app)
- Git repository

### Deploy Steps

1. **Connect Repository**
   ```bash
   git push origin main
   ```

2. **Connect to Railway**
   - Go to railway.app
   - Create new project
   - Select "Deploy from GitHub"
   - Connect your repository

3. **Railway Configuration**
   - The `railway.json` is automatically detected
   - Environment variables are pre-configured
   - Default PORT: 8080

4. **Health Check**
   - Railway monitors `/Yas` endpoint
   - Auto-restarts on failure
   - Logs available in Railway dashboard

## PWA Features

### Service Worker
- Network-first caching strategy
- Offline fallback to cached pages
- Automatic cache updates
- Background sync support

### Manifest
- App name and description
- Home screen shortcuts
- Multiple icon formats
- Theme colors optimized for both platforms

### Meta Tags
- iOS notch/safe-area support
- Theme color configuration
- Status bar styling
- Format detection

## Architecture

```
/Program.cs              - Main API routes and home page
/reasons.cs              - Reasons page endpoint
/relationship.cs         - Relationship timeline endpoint
/more.cs                 - Additional content endpoint
/wwwroot/
  ├── sw.js              - Service Worker
  ├── manifest.json      - PWA manifest
  ├── icon.svg           - App icon
  ├── fun.html           - Fun page
  └── secret.html        - Easter egg
/Dockerfile              - Railway container config
/railway.json            - Railway deployment config
```

## Mobile Optimization

- ✅ Responsive design (mobile-first)
- ✅ Touch-friendly UI (48px min tap targets)
- ✅ Optimized font sizes
- ✅ Safe-area support for notches
- ✅ Fast loading times
- ✅ Smooth animations
- ✅ No user-select on interactive elements

## Browser Support

- ✅ Chrome/Chromium (Android)
- ✅ Safari (iOS 11+)
- ✅ Edge
- ✅ Firefox

## Environment Variables

- `PORT` - Server port (default: 8080, Railway sets this automatically)
- `ASPNETCORE_URLS` - Server binding URL

## Performance

- First Contentful Paint: <1s
- Fully Interactive: <2s
- Service Worker Cache: Instant on offline
- Mobile-optimized images and fonts

## License

Made with love ❤️
